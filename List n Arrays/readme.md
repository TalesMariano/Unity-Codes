https://www.geeksforgeeks.org/how-to-sort-list-in-c-sharp-set-1/

https://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object

https://stackoverflow.com/questions/32191695/how-to-sort-class-list-by-integer-property

https://stackoverflow.com/questions/5344805/linq-orderby-descending-query

https://www.guru99.com/c-sharp-inheritance-polymorphism.html


----

## Dictionary

* https://learn.unity.com/tutorial/lists-and-dictionaries
* https://www.youtube.com/watch?v=GaM6uR6CJMg



        //You can place variables into the Dictionary with the
        //Add() method.
        badguys.Add("gangster", bg1);
        badguys.Add("mutant", bg2);

        BadGuy magneto = badguys["mutant"];

        BadGuy temp = null;

        //This is a safer, but slow, method of accessing
        //values in a dictionary.
        if(badguys.TryGetValue("birds", out temp))
        {
            //success!
        }
        else
        {
            //failure!
        }
