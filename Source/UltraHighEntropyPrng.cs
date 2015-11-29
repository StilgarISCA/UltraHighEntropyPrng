using System;
using System.CodeDom;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Yakhair.Ports.Grc.UhePrng
{
   public class UltraHighEntropyPrng
   {
      private int _order;
      private double _carry;
      private int _phase;
      private double[] _intermediates;
      private int _k; // general purpose locals
      private Mash _mash;

      private readonly Random _random = new Random(); // Used to simulate javascript's Math.random

      public UltraHighEntropyPrng()
      {
         _order = 48; // set the 'order' number of ENTROPY-holding 32-bit values
         _carry = 1;  // init the 'carry' used by the multiply-with-carry (MWC) algorithm
         _phase = _order; // init the 'phase' (max-1) of the intermediate variable pointer
         _intermediates = new double[_order]; // declare our intermediate variables array

         // when our "uheprng" is initially invoked our PRNG state is initialized from the
         // browser's own local PRNG. This is okay since although its generator might not
         // be wonderful, it's useful for establishing large startup entropy for our usage.		
         _mash = new Mash();		// get a pointer to our high-performance "Mash" hash
         for ( int i = 0; i < _order; i++ )
         {
            _intermediates[i] = _mash.DoMash( _random.NextDouble() );	// fill the array with initial mash hash values
         }
      }

      // this EXPORTED function is the default function returned by this library.
      // The values returned are integers in the range from 0 to range-1. We first
      // obtain two 32-bit fractions (from rawprng) to synthesize a single high
      // resolution 53-bit prng (0 to <1), then we multiply this by the caller's
      // "range" param and take the "floor" to return a equally probable integer.
      public dynamic Random( int range )
      {
         var tmp = (int) ( RawPrng() * 0x200000 );
         return Math.Floor( range * ( RawPrng() + ( tmp | 0 ) * 1.1102230246251565e-16 ) ); // 2^-53
      }

      // this EXPORTED function 'string(n)' returns a pseudo-random string of
      // 'n' printable characters ranging from chr(33) to chr(126) inclusive.
      public string RandomString( int count )
      {
         var stringBuilder = new StringBuilder();
         for ( int i = 0; i < count; i++ )
         {
            char newChar = Convert.ToChar( 33 + (int) Random( 94 ) );
            stringBuilder.Append( newChar );
         }
         return stringBuilder.ToString();
      }

      // this PRIVATE (internal access only) function is the heart of the multiply-with-carry
      // (MWC) PRNG algorithm. When called it returns a pseudo-random number in the form of a
      // 32-bit JavaScript fraction (0.0 to <1.0) it is a PRIVATE function used by the default
      // [0-1] return function, and by the random 'string(n)' function which returns 'n'
      // characters from 33 to 126.
      private double RawPrng()
      {
         if ( ++_phase >= _order )
         {
            _phase = 0;
         }
         var t = 1768863 * _intermediates[_phase] + _carry * 2.3283064365386963e-10; // 2^-32
         _carry = (int) t | 0;
         _intermediates[_phase] = t - _carry;
         return _intermediates[_phase];
      }

      /// <summary>
      /// Evolve the generator's internal entropy state
      /// </summary>
      /// <param name="args"></param>
      /// <seealso cref="AddEntropy"/>
      private void Hash( string args )
      {
         for ( int i = 0; i < args.Length; i++ )
         {
            for ( int j = 0; j < _order; j++ )
            {
               _intermediates[j] -= _mash.DoMash( args[i] );
               if ( _intermediates[j] < 0 )
               {
                  _intermediates[j] = ( _intermediates[j] + 1 );
               }
            }
         }
      }

      /// <summary>
      /// Removes leading and trailing spaces and non-printing control
      /// characters, including any embedded carriage-return (CR) and
      /// line-feed (LF) characters, from any string it is handed
      /// </summary>
      /// <param name="toClean"></param>
      /// <returns></returns>
      public string CleanString( string toClean )
      {
         string cleaned = toClean.Trim(); // remove any/all leading/trailing spaces

         // remove any/all control characters
         const string controlCharactersPattern = "[\x00-\x1F]";
         var cleanControlCharacters = new Regex( controlCharactersPattern );
         cleaned = cleanControlCharacters.Replace( cleaned, string.Empty );

         return cleaned; // return the cleaned up result
      }

      // this EXPORTED "hash string" function hashes the provided character string after first removing
      // any leading or trailing spaces and ignoring any embedded carriage returns (CR) or Line Feeds (LF)
      public void HashString( string input )
      {
         input = CleanString( input );
         _mash.DoMash( input );											// use the string to evolve the 'mash' state

         char[] inputAry = input.ToCharArray();
         for ( int i = 0; i < inputAry.Length; i++ )   // scan through the characters in our string
         {
            _k = inputAry[i];      						// get the character code at the location
            for ( int j = 0; j < _order; j++ )			//	"mash" it into the UHEPRNG state
            {
               _intermediates[j] -= _mash.DoMash( _k );
               if ( _intermediates[j] < 0 )
               {
                  _intermediates[j] += 1;
               }
            }
         }
      }

      /// <summary>
      /// Used to add additional entropy to the Prng
      /// </summary>
      /// <param name="values">Variable number of parameters used to generate additional entropy</param>
      public void AddEntropy( params string[] values )
      {
         Hash( ( _k++ ) + ( DateTime.UtcNow.Ticks ) + string.Join( string.Empty, values ) + _random.Next( 0, int.MaxValue ) );
      }

      // if we want to provide a deterministic startup context for our PRNG,
      // but without directly setting the internal state variables, this allows
      // us to initialize the mash hash and PRNG's internal state before providing
      // some hashing input
      public void InitState()
      {
         _mash.DoMash( null );												// pass a null arg to force mash hash to init
         for ( int i = 0; i < _order; i++ )
         {
            _intermediates[i] = _mash.DoMash( ' ' );	// fill the array with initial mash hash values
         }
         _carry = 1;													// init our multiply-with-carry carry
         _phase = _order;  										// init our phase
      }
   }
}