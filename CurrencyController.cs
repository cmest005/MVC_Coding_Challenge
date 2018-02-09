using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestingTextRead.Models;
using System.IO;

namespace TestingTextRead.Controllers
{
    public class CurrencyController : Controller
    {
        // GET: Currency
        public ActionResult Index()
        {
            return View();
        }


        //  [HttpGet]
        public ActionResult Currency()
        {

            var list = new List<string>();

            /* Sample data:
             * Testing the given sample, when N>D, D>N, and many datasets.
            */
            //var path = Server.MapPath(@"~/App_Data/2sets_D2N2_D3N3.txt");
            //var path = Server.MapPath(@"~/App_Data/1set_D2N5.txt");
            //var path = Server.MapPath(@"~/App_Data/1set_D3N2.txt");
            var path = Server.MapPath(@"~/App_Data/16sets.txt");

            using (var sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }

            /* Variables used for calculations */
            string[] result = list.ToArray(); //read textfile into an array
            int datasets = Int32.Parse(result[0]); //# of datasets
            int x = 0; //counter for datasets
            int q = 1; //grab only the n d lines
            int temp = 0; //holder for maintaining position for line iteration.
            int[] arraySize = new int[datasets];  //keeps track of n for results
            int[][] resultArrays = new int[datasets][]; //final results after calculations


            for (int i = 0; i < datasets; i++)
                resultArrays[i] = new int[10]; //arrays used to store dataset returns for computation.

            /* Loop through k datasets, and save results to arrays.*/
            do
            {
                string[] dn = result[q].Split(' ');
                int d = Int32.Parse(dn[0]); // Value of D
                int n = Int32.Parse(dn[1]); // Value of N
                string[] notes = new string[7];
                temp = q + 2;

                if (d - 1 > 1)
                {
                    notes = result[q + 1].Split(' '); // Currency multiplicants
                }
                else
                    notes[0] = result[q + 1]; // Currency multiplicants

                int[][] currency = new int[d][];

                 for (int i = 0; i < d; i++)
                     currency[i] = new int[n]; //arrays of different types of currency (foo, bar,...)

                string[][] values = new string[n][];

                for (int i = 3; i < n + 3; i++)
                    values[i - 3] = result[temp++].Split(' '); //arrays of lines of currency amounts (2 0, 3 0 0)
           
                int[] sum = new int[n]; //total of the highest currency
                int k = 0;
                int times = 0;
                
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < d; j++)
                    {
                        if (j < d - 1)
                            sum[k] = (sum[k] + Int32.Parse(values[i][j])) * Int32.Parse(notes[times]);
                        else
                            sum[k] = sum[k] + Int32.Parse(values[i][j]);
                        if (n - 1 > 0)
                            times++;
                    }
                    times = 0;
                    k++;
                }

                //Sort Array for input into result
                Array.Sort(sum);

                //Size of Array for calculating max-min values
                arraySize[x] = n;

                // create a jagged array to return results for sorting
               for (int i = 0; i < n; i++)
                   resultArrays[x][i] = sum[i];

                q = q + n + 2;
                x++;
            } while (x < datasets);

            // populate a final array with the largest difference 
            int[] dataSetOutput = new int[datasets];
            for (int i = 0; i < datasets; i++)
            {
                dataSetOutput[i] = resultArrays[i][arraySize[i] - 1] - resultArrays[i][0];
            }

            /* Send final results array to html collection */
            ViewBag.CollectionResults = dataSetOutput;
            ViewBag.CollectionDataSet = result;

            return View();
        }

        public ActionResult TestViewData()
        {
            ViewData["Name"] = "Carlos";
            return View();
        }
    }
}