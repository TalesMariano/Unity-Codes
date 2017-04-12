    int[] ShuffleIntArr(int[] arr){

       // int n = arr.Length;  

        for (int t = 0; t < arr.Length; t++ )
        {
            int tmp = arr[t];
            int r = UnityEngine.Random.Range(t, arr.Length);
            arr[t] = arr[r];
            arr[r] = tmp;
        }


        /*
        System.Random rng = new System.Random();  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            int value = arr[k];  
            arr[k] = arr[n];  
            arr[n] = value;  
        }  */

        return arr;
    }
