//var candies = 7;
//var num_people = 4;

var candies = 60;
var num_people = 4;
var result = DistributeCandies(candies, num_people);
Console.WriteLine(result);


int[] DistributeCandies(int cadies, int num_people)
{
    var arr = new int[num_people];

    var ctr = 0;
    var candiesToGive = ctr + 1;

    var idx = ctr % num_people;

    while(candies >= candiesToGive)
    {
        idx = ctr % num_people;

        arr[idx] += candiesToGive;
        ctr++;
        candies -= candiesToGive;
        candiesToGive = ctr+1;
    }


    if (candies > 0)
    {
        idx = ctr % num_people;
        arr[idx] += candies;
    }

    return arr;
}
