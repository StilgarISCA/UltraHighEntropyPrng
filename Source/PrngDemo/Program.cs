using System;
using System.Windows.Forms;

namespace PrngDemo
{
   // The async pattern here is based on:
   // https://msdn.microsoft.com/en-us/magazine/mt620013
   public class Program
   {
      private readonly Form1 _form1;

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      public static void Main()
      {
         var program = new Program();
         program.Start();
      }
     
      private Program()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault( false );

         _form1 = new Form1();
         _form1.FormClosed += Form1OnClose;

      }

      private static void Form1OnClose( object sender, FormClosedEventArgs e )
      {
         Application.ExitThread();
      }

      public void Start()
      {
         _form1.Initialize();
         _form1.Show();

         Application.Run();
      }
   }
}
