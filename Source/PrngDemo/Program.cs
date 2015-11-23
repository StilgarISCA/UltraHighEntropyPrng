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
      static void Main()
      {
         var program = new Program();
         program.Start();
      }
     
      private Program()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault( false );
         _form1 = new Form1();

      }

      public void Start()
      {
         Application.Run( _form1 );
      }
   }
}
