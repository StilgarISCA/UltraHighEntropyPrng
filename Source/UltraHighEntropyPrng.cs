﻿
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Yakhair.Ports.Grc.UhePrng
{
   public class UltraHighEntropyPrng
   {
      private dynamic _order;
      private dynamic _carry;
      private dynamic _phase;
      private Array _intermediates;
      private dynamic _i, _j, _k; // general purpose locals

      private readonly Random _random = new Random(); // Used to simulate javascript's Math.random

      public UltraHighEntropyPrng()
      {
         _order = 48; // set the 'order' number of ENTROPY-holding 32-bit values
         _carry = 1;  // init the 'carry' used by the multiply-with-carry (MWC) algorithm
         _phase = _order; // init the 'phase' (max-1) of the intermediate variable pointer
         _intermediates = var[_order]; // declare our intermediate variables array

         // when our "uheprng" is initially invoked our PRNG state is initialized from the
         // browser's own local PRNG. This is okay since although its generator might not
         // be wonderful, it's useful for establishing large startup entropy for our usage.		
         //var mash = Mash();		// get a pointer to our high-performance "Mash" hash
         for ( _i = 0; _i < _order; _i++ )
         {
            _intermediates[_i] = Mash( _random.Next( 0, int.MaxValue ) );	// fill the array with initial mash hash values
         }
      }

      // this EXPORTED function is the default function returned by this library.
      // The values returned are integers in the range from 0 to range-1. We first
      // obtain two 32-bit fractions (from rawprng) to synthesize a single high
      // resolution 53-bit prng (0 to <1), then we multiply this by the caller's
      // "range" param and take the "floor" to return a equally probable integer.
      public dynamic Random( dynamic range )
      {
         return Math.Floor( range * ( RawPrng() + ( RawPrng() * 0x200000 | 0 ) * 1.1102230246251565e-16 ) ); // 2^-53
      }

      // this EXPORTED function 'string(n)' returns a pseudo-random string of
      // 'n' printable characters ranging from chr(33) to chr(126) inclusive.
      private dynamic RandomString( dynamic count )
      {
         var stringBuilder = new StringBuilder();
         for ( int i = 0; i < count; i++ )
         {
            char newChar = ( 33 + Random( 94 ) ).ToCharArray()[0];
            stringBuilder.Append( newChar );
         }
         return stringBuilder;
      }

      // this PRIVATE (internal access only) function is the heart of the multiply-with-carry
      // (MWC) PRNG algorithm. When called it returns a pseudo-random number in the form of a
      // 32-bit JavaScript fraction (0.0 to <1.0) it is a PRIVATE function used by the default
      // [0-1] return function, and by the random 'string(n)' function which returns 'n'
      // characters from 33 to 126.
      private dynamic RawPrng()
      {
         if ( ++_phase >= _order )
         {
            _phase = 0;
         }
         var t = 1768863 * _intermediates[_phase] + _carry * 2.3283064365386963e-10; // 2^-32
         return _intermediates[_phase] = t - ( _carry = t | 0 );
      }

      // this PRIVATE "hash" function is used to evolve the generator's internal
      // entropy state. It is also called by the EXPORTED addEntropy() function
      // which is used to pour entropy into the PRNG.
      private void Hash( string[] args )
      {
         for ( _i = 0; _i < args.Length; _i++ )
         {
            for ( _j = 0; _j < _order; _j++ )
            {
               _intermediates[_j] -= Mash( args[_i] );
               if ( _intermediates[_j] < 0 )
               {
                  _intermediates[_j] += 1;
               }
            }
         }
      }

      // this EXPORTED "clean string" function removes leading and trailing spaces and non-printing
      // control characters, including any embedded carriage-return (CR) and line-feed (LF) characters,
      // from any string it is handed. this is also used by the 'hashstring' function (below) to help
      // users always obtain the same EFFECTIVE uheprng seeding key.
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
      public dynamic HashString( string inStr )
      {
         inStr = CleanString( inStr );
         Mash( inStr );											// use the string to evolve the 'mash' state
         for ( _i = 0; _i < inStr.Length; _i++ )       // scan through the characters in our string
         {
            _k = inStr.charCodeAt( _i );						// get the character code at the location
            for ( _j = 0; _j < _order; _j++ )						//	"mash" it into the UHEPRNG state
            {
               _intermediates[_j] -= Mash( _k );
               if ( _intermediates[_j] < 0 )
               {
                  _intermediates[_j] += 1;
               }
            }
         }
      }

      // this handy exported function is used to add entropy to our uheprng at any time
      public void AddEntropy( /* accept zero or more arguments */ )
      {
         var args = [];
         for (_i = 0; _i < arguments.Length; i++)
         {
            args.push( arguments[_i] );
         }
         Hash( (_k++) + ( DateTime.UtcNow ) + args.join( string.Empty ) + _random.Next( 0, int.MaxValue ) );
      }

      // if we want to provide a deterministic startup context for our PRNG,
      // but without directly setting the internal state variables, this allows
      // us to initialize the mash hash and PRNG's internal state before providing
      // some hashing input
      public void InitState()
      {
         Mash();													// pass a null arg to force mash hash to init
         for ( _i = 0; _i < _order; _i++ )
         {
            _intermediates[_i] = Mash( ' ' );	// fill the array with initial mash hash values
         }
         _carry = 1;													// init our multiply-with-carry carry
         _phase = _order;  										// init our phase
      }

      /// <summary>
      /// Hashing function
      /// </summary>
      /// <param name="data">Data to hash</param>
      /// <returns>Hashed value</returns>
      /// <remarks> This is based upon Johannes Baagoe's carefully designed and efficient hash function for use with JavaScript.  It has a proven "avalanche" effect such that every bit of the input affects every bit of the output 50% of the time, which is good.</remarks>
      /// <seealso cref="https://web.archive.org/web/20111119022126/http://baagoe.org/en/wiki/Better_random_numbers_for_javascript"/>
      private dynamic Mash( dynamic data )
      {
         var n = 0xefc8249d;

         if ( data != null )
         {
            data = data.toString();
            for ( var i = 0; i < data.length; i++ )
            {
               n += data.charCodeAt( i );
               var h = 0.02519603282416938 * n;
               n = Convert.ToUInt32( h ); // original: n = h >>> 0;
               h -= n;
               h *= n;
               n = Convert.ToUInt32( h ); // original: n = h >>> 0;
               h -= n;
               n += h * 0x100000000; // 2^32
            }
            return ( Convert.ToUInt32( n ) ) * 2.3283064365386963e-10; // 2^-32
         }

         return n;
      }

      /// <summary>
      /// Hashing function
      /// </summary>
      /// <see cref="Mash()"/>
      private dynamic Mash()
      {
         return Mash( null );
      }
   }
}