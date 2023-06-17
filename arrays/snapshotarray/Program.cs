using SnapshotArrayNs;

Console.WriteLine("Hello, World!");

var s = new SnapshotArray(4);

s.Set(0, 5);

s.Snap();

s.Set(0, 6);

var r = s.Get(0, 0);

//s.Set(1, 5);
//s.Set(2, 4);
//
//s.Snap();
//s.Snap();
//s.Snap();
//
//s.Set(1, 9);
//
//s.Snap();
//s.Snap();
//
//var x = s.Get(1, 0);
//x = s.Get(1, 1);
//x = s.Get(1, 2);
//
Console.Read();
