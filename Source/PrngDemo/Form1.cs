using System;
using System.Windows.Forms;
using Yakhair.Ports.Grc.UhePrng;

namespace PrngDemo
{
   public partial class Form1 : Form
   {
      public const double _log10e = 2.302585092994045684017991454684364;

      private UltraHighEntropyPrng _prng;
      private int _eventCount;


      public Form1()
      {
         InitializeComponent();

         _prng = new UltraHighEntropyPrng();  // instantiate our uheprng for requesting PRNs
         _eventCount = 0;		// this counts events to introduce a (small) bit of additional entropy
         var i = string.Empty;   	// general purpose local vars
         var s = string.Empty;
         lblStatus.Text = string.Empty;
         AddEntropy();
      }

      // this 'Generate' function is called whenever the user presses the "Generate Random Numbers" button on the web page.
      // it takes the currently displayed contents of the "SeedKey" region to initialize the UHEPRNG into a known state,
      // then generates the user-specified number of pseudo-random numbers having the requested range (0 to n-1).
      private void Generate()
      {
         var display = string.Empty;													// this is the string that we'll be placing into the PRN display DIV
         int range = Convert.ToInt32( numRange.Value );				// pull the form's parameters for our generation
         int count = Convert.ToInt32( numRange.Value );
         var digits = Math.Floor( _log10e * Math.Log( range - 1 ) ) + 1;	// maximum number of digits in the "range"

         // perform some preliminary parameter sanity checking
         if ( range <= 1 )
         {
            lblStatus.Text += "The \"Range\" specified must be at least \"2\" so that values can be 0 or 1 — thus 2 values";
         }

         if ( count == 0 )
         {
            lblStatus.Text += "The \"Count\" of random values requested must be at least 1.";
         }

         if ( display == string.Empty )
         {
            // we are about to generate our PRNs, so we capture the current "SeedKey"
            // from the webpage's form field and use it to setup our PRNG
            _prng.InitState();																// init the PRNG and its private hash function
            _prng.HashString( rtbSeedKey.Text );


            // with the PRNG initialized into a known starting state by the provided SeedKey
            // we now pull the requested number of pseudo-random numbers from our the generator
            for ( var i = 0; i < count; i++ )
            {					// iterate through, concatenating PRNs to the 'display' string
               //string s = _prng( range ).toString();					// call our PRNG and convert the return to a string
               string s = _prng.Random( range ).ToString();
               while ( s.Length < digits ) // left-zero pad the result out to the maximum length of digits
               {
                  s = '0' + s;
               }
               display += s + ' ';								// concatenate the new string onto our growing 'display' string
            }
         }
         // with all of the numbers collected, place the final 'display' string into the 'prns' DIV
         rtbRandom.Text = display;
      }

   // this 'addEntropy' function calls the UHEPRNG's built-in hashing function with whatever (optional)
   // arguments it is provided, plus a count, the current time and a random value from the local browser
   // as a means of pouring additional entropy into the UHEPRNG's internal state.
   // Note that the invocation of the UHEPRNG initializes the PRNG with a large amount of initial entropy.
   private void AddEntropy()
   {
      _prng.AddEntropy();
      rtbSeedKey.Text = _prng.RandomString( 256 );				// obtain 256 random printable characters
   }

      private void btnGenerate_Click( object sender, EventArgs e )
      {
         Generate();
      }
   }
}
