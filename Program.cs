Console.WriteLine("Whats your starting path");
string? startPath = Console.ReadLine();
Console.WriteLine("What word are you searching for?");
string? searchTerm = Console.ReadLine();
List<string> files = new List<string>();
List<string> directory = new List<string>();
List<string> hasTerm = new List<string>();
void GetDirectories(string path){
var direct = Directory.GetDirectories(path);
foreach (string d in direct){
    directory.Add(d);
    getfiles(d);
   // Console.WriteLine(d);
}
}


GetDirectories(startPath);

for (int x =0; x < directory.Count(); x++){
    GetDirectories(directory[x]);
     
}
/*
for (int x =0; x <= files.Count(); x++){
    getfiles(files[x]);
     
}
*/
void getfiles (string path){
var file = Directory.GetFiles(path);
foreach (string f in file){
    if (searching(f))
    files.Add(Path.GetFullPath(f));
    //Console.WriteLine(f);

}
}
foreach (string x in files){
    Console.WriteLine(x);
}
File.WriteAllLines("files.csv", files);
Console.ReadKey();

bool searching(string f){
var fileContains = File.ReadAllText(f);
if (fileContains.Contains(searchTerm)){
    return true;
}
else{
    return false;
}
}
