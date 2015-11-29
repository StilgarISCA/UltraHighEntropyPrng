using System;

namespace Yakhair.Ports.Grc.UhePrng
{
   /// <summary>
   /// Encapsulates functionality related to the Mash hashing functionality
   /// </summary>
   public class Mash
   {
      private uint _mashEntropy;
      private const uint _initialValue = 0xefc8249d; //4022871197

      /// <summary>
      /// Initializes a new instance of the Mash class 
      /// </summary>
      public Mash()
      {
         _mashEntropy = _initialValue;
      }

      /// <summary>
      /// Hashing function
      /// </summary>
      /// <param name="data">Data to hash; null to reinitialize</param>
      /// <returns>Hashed value</returns>
      /// <remarks> This is based upon Johannes Baagoe's carefully designed and efficient hash function for use with JavaScript.  It has a proven "avalanche" effect such that every bit of the input affects every bit of the output 50% of the time, which is good.</remarks>
      /// <seealso cref="https://web.archive.org/web/20111119022126/http://baagoe.org/en/wiki/Better_random_numbers_for_javascript"/>
      /// <seealso cref="https://github.com/nquinlan/better-random-numbers-for-javascript-mirror/blob/8101d7cd95831b074f183e1f0ecb64ff207448a5/support/c/mash.h"/>
      public double DoMash( dynamic data )
      {
         // It seems like using a Reset() method is more appropriate than using null to reinitialize
         if ( data != null )
         {
            data = data.ToString();
            for ( var i = 0; i < data.Length; i++ )
            {
               _mashEntropy += data.ToCharArray()[i];
               double h = 0.02519603282416938 * _mashEntropy;
               _mashEntropy = Convert.ToUInt32((int) h >> 0);
               h -= _mashEntropy;
               h *= _mashEntropy;
               _mashEntropy = Convert.ToUInt32( (int) h >> 0 );
               h -= _mashEntropy;
               _mashEntropy += Convert.ToUInt32( h * 0x100000000 ); // 2^32
            }
            return ( Convert.ToUInt32( _mashEntropy >> 0 ) * 2.3283064365386963e-10 ); // 2^-32
         }

         return _mashEntropy = _initialValue;
      }
   }
}