using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrngDemo
{
   // The async pattern here is based on:
   // https://msdn.microsoft.com/en-us/magazine/mt620013
   public class Program
   {
      private readonly Form1 _form1;
      public event EventHandler<EventArgs> ExitRequested;

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      public static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault( false );
         SynchronizationContext.SetSynchronizationContext( new WindowsFormsSynchronizationContext() );

         var program = new Program();
         program.ExitRequested += OnExitRequested;

         Task programStart = program.StartAsync();
         HandleExceptions( programStart );

         Application.Run();
      }
     
      private Program()
      {
         _form1 = new Form1();
         _form1.FormClosed += Form1OnClose;
      }

      private static async void HandleExceptions( Task task )
      {
         try
         {
            await Task.Yield(); //ensure this runs as a continuation
            await task;
         }
         catch ( Exception ex )
         {
            //deal with exception, either with message box
            //or delegating to general exception handling logic you may have wired up 
            //e.g. to Application.ThreadException and AppDomain.UnhandledException
            MessageBox.Show( ex.ToString() );

            Application.Exit();
         }
      }

      private void Form1OnClose( object sender, FormClosedEventArgs e )
      {
         OnExitRequested( EventArgs.Empty );
      }

      static void OnExitRequested( object sender, EventArgs e )
      {
         Application.ExitThread();
      }

      protected virtual void OnExitRequested( EventArgs e )
      {
         if ( ExitRequested != null )
         {        
            ExitRequested( this, e );
         }
      }

      public async Task StartAsync()
      {
         await _form1.InitializeAsync();
         _form1.Show();
      }
   }
}
