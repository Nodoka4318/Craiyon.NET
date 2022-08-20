using System;
using Craiyon;

namespace SampleCraiyonImageGenerator {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine(@"
   ******                   **                               ****     ** ******** **********
  **////**                 //   **   **                     /**/**   /**/**///// /////**/// 
 **    //  ******  ******   ** //** **   ******  *******    /**//**  /**/**          /**    
/**       //**//* //////** /**  //***   **////**//**///**   /** //** /**/*******     /**    
/**        /** /   ******* /**   /**   /**   /** /**  /**   /**  //**/**/**////      /**    
//**    ** /**    **////** /**   **    /**   /** /**  /** **/**   //****/**          /**    
 //****** /***   //********/**  **     //******  ***  /**/**/**    //***/********    /**    
  //////  ///     //////// //  //       //////  ///   // // //      /// ////////     //     ");

            Console.Write("\n\n\nWhat do you want to see? >> ");
            var prompt = Console.ReadLine();
            
            using (var craiyon = new CraiyonClient()) {
                var images = craiyon.GenerateImageAsync(prompt);

                Console.CursorVisible = false;
                char[] bars = { '／', '―', '＼', '｜' };
                int i = 0;
                while (!images.IsCompleted) {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write($"{bars[i % 4]} generating..");                
                    i++;
                    System.Threading.Thread.Sleep(100);
                }
                Console.WriteLine("\tdone!\n");

                images.Result.SaveImages(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));

                Console.WriteLine($"images were saved at {Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}\npress any key to exit..");
                Console.ReadKey();
            }
        }
    }
}
