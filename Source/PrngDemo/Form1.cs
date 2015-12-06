using System;
using System.Windows.Forms;
using Yakhair.Ports.Grc.UhePrng;

namespace PrngDemo
{
   public partial class Form1 : Form
   {
      private UltraHighEntropyPrng _prng;
      private int _eventCount;

      public Form1()
      {
         InitializeComponent();

         _prng = new UltraHighEntropyPrng();  // instantiate our uheprng for requesting PRNs
         _eventCount = 0;		// this counts events to introduce a (small) bit of additional entropy
         lblStatus.Text = string.Empty;
         AddEntropy();
         bkWkrSeedGenerator.RunWorkerAsync();
      }

      // this 'Generate' function is called whenever the user presses the "Generate Random Numbers" button on the web page.
      // it takes the currently displayed contents of the "SeedKey" region to initialize the UHEPRNG into a known state,
      // then generates the user-specified number of pseudo-random numbers having the requested range (0 to n-1).
      private void Generate()
      {
         var display = string.Empty;													// this is the string that we'll be placing into the PRN display DIV
         int range = Convert.ToInt32( numRange.Value );				// pull the form's parameters for our generation
         int count = Convert.ToInt32( numRange.Value );
         double digits = Math.Floor( Math.Log10( Math.E ) * Math.Log( range - 1 ) ) + 1;	// maximum number of digits in the "range"

         // perform some preliminary parameter sanity checking
         if ( range <= 1 )
         {
            lblStatus.Text += "The \"Range\" specified must be at least \"2\" so that values can be 0 or 1 — thus 2 values";
         }

         if ( count == 0 )
         {
            lblStatus.Text += "The \"Count\" of random values requested must be at least 1.";
         }

         if ( string.IsNullOrWhiteSpace( display ) )
         {
            // we are about to generate our PRNs, so we capture the current "SeedKey"
            // from the webpage's form field and use it to setup our PRNG
            _prng.InitState();																// init the PRNG and its private hash function
            _prng.HashString( rtbSeedKey.Text );


            // with the PRNG initialized into a known starting state by the provided SeedKey
            // we now pull the requested number of pseudo-random numbers from our the generator
            for ( int i = 0; i < count; i++ )
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

      private void btnReset_Click( object sender, EventArgs e )
      {
         rtbRandom.Text = string.Empty;
         rdoRandomize.Checked = true;
         numRange.Value = 10000;
         numCount.Value = 10000;
      }

      private void bkWkrSeedGenerator_DoWork( object sender, System.ComponentModel.DoWorkEventArgs e )
      {
         while ( rdoRandomize.Checked )
         {
            _prng.AddEntropy();
            bkWkrSeedGenerator.ReportProgress(1);

            if ( bkWkrSeedGenerator.CancellationPending )
            {
               e.Cancel = true;
               return;
            }
         }
      }

      private void bkWkrSeedGenerator_ProgressChanged( object sender, System.ComponentModel.ProgressChangedEventArgs e )
      {
         rtbSeedKey.Text = _prng.RandomString( 256 );
      }

      private void bkWkrSeedGenerator_RunWorkerCompleted( object sender, System.ComponentModel.RunWorkerCompletedEventArgs e )
      {
         rtbSeedKey.Text = _prng.RandomString( 256 );
      }

      private void rdoRandomize_CheckedChanged( object sender, EventArgs e )
      {
         SetWorkerState();
      }

      private void SetWorkerState()
      {
         if ( rdoRandomize.Checked )
         {
            bkWkrSeedGenerator.RunWorkerAsync();
         }
         else
         {
            bkWkrSeedGenerator.CancelAsync();
         }
      }

      private void rdoFreeze_CheckedChanged( object sender, EventArgs e )
      {
         SetWorkerState();
      }
   }
}
