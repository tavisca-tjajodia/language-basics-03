using System;
using System.Linq;
using System.Collections.Generic;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            
            int[] calorie = new int[protein.Length];

            for(int i = 0; i < protein.Length; i++){
                calorie[i] = 5 * (protein[i] + carbs[i]) + 9 * fat[i];
            }

            int[] solution = new int[dietPlans.Length];            

            for(int i = 0; i < dietPlans.Length; i++){
                
                List<int> possibleIndexes = new List<int>();
                string dietPlan = dietPlans[i];

                if(dietPlan.Length == 0){
                    solution[i] = 0;
                    continue;
                }

                for(int k = 0; k < protein.Length; k++)
                {
                    possibleIndexes.Add(k);
                }

                foreach(char ch in dietPlan){                    
                    if(ch.Equals('p')){
                        int min = getMinimumValue(protein,possibleIndexes);
                        // Console.WriteLine($"Debugging ===== >p {min}");
                        possibleIndexes = getMinimumIndexes(protein,possibleIndexes,min);
                    }
                    else if(ch.Equals('P'))
                    {
                        int max = getMaximumValue(protein,possibleIndexes);
                        // Console.WriteLine($"Debugging ===== >P {max}");
                        possibleIndexes = getMinimumIndexes(protein,possibleIndexes,max);
                    }
                    else if(ch.Equals('c')){
                        int min = getMinimumValue(carbs,possibleIndexes);
                        // Console.WriteLine($"Debugging ===== >c {min}");
                        possibleIndexes = getMinimumIndexes(carbs,possibleIndexes,min);
                    }
                    else if(ch.Equals('C')){
                        int max = getMaximumValue(carbs,possibleIndexes);
                        // Console.WriteLine($"Debugging ===== >C {max}");
                        possibleIndexes = getMinimumIndexes(carbs,possibleIndexes,max);
                    }
                    else if(ch.Equals('f')){
                        int min = getMinimumValue(fat,possibleIndexes);
                        // Console.WriteLine($"Debugging ===== >f {min}");
                        possibleIndexes = getMinimumIndexes(fat,possibleIndexes,min);
                    }
                    else if(ch.Equals('F')){
                        int max = getMaximumValue(fat,possibleIndexes);
                        // Console.WriteLine($"Debugging ===== >F {max}");
                        possibleIndexes = getMinimumIndexes(fat,possibleIndexes,max);
                    }
                    else if(ch.Equals('t')){
                        int min = getMinimumValue(calorie,possibleIndexes);
                        // Console.WriteLine($"Debugging ===== >t {min}");
                        possibleIndexes = getMinimumIndexes(calorie,possibleIndexes,min);
                    }
                    else if(ch.Equals('T')){
                        int max = getMaximumValue(calorie,possibleIndexes);
                        // Console.WriteLine($"Debugging ===== >T {max}");
                        possibleIndexes = getMinimumIndexes(calorie,possibleIndexes,max);
                    }
                }

                solution[i] = possibleIndexes[0];


            }
            // Console.WriteLine("==========================");

            // for(int j = 0; j < solution.Length ;j++){
            //     Console.Write(solution[j]+" ");
            // }


            // Console.WriteLine("\n"+"==========================");
            return solution;
            throw new NotImplementedException();
        
        }

        public static List<int> getMinimumIndexes(int[] arr,List<int> possibleIndexes,int value){

        List<int> temp = new List<int>();
        for(int i = 0; i < possibleIndexes.Count; i++){
            if(arr[possibleIndexes[i]] == value){
                temp.Add(possibleIndexes[i]);
            }
        }        
        return temp;
        }

        public static int getMinimumValue(int[] arr, List<int> possibleIndexes){
            
            int min = int.MaxValue;

            for(int i = 0; i < possibleIndexes.Count; i++){
                if(min > arr[possibleIndexes[i]]){
                    min = arr[possibleIndexes[i]];
                }
            }

            return min;
        } 
        public static int getMaximumValue(int[] arr, List<int> possibleIndexes){
            int max = int.MinValue;

            for(int i = 0; i < possibleIndexes.Count; i++){
                if(max < arr[possibleIndexes[i]]){
                    max = arr[possibleIndexes[i]];
                }
            }
            return max;
        }
    }

        


}
