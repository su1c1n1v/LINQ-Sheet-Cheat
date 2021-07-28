# **LINQ Sheet Cheat**

### In this project i will show how to work with LINQ
- To begin i created a class to use as a example and create a List<Users> to use the LINQ
---

## Variables

- Type Users
```C#    
public class Users
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Job Job { get; set; }

	public Users(int Id, string Name, Job Job)
    {
        this.Job = Job;
        this.Name = Name;
        this.Id = Id;
    }

    public override string ToString()
    {
         return "ID: " + Id + ", Name: " + Name + ", Job: " + Job;
    }
}
```

- enum to specify a Job
```C#
public enum Job
{
    Developer = 1,
    Driver = 2,
    Jornalist = 3,
    Interviewer = 4,
    Youtuber = 5
}
```
- Fill a List of Users
```C#
List<Users> list = new List<Users>()
{
    new Users(1,"Vinicius",Job.Developer),
    new Users(2,"Rodrigues",Job.Jornalist),
    new Users(3,"Silva",Job.Developer),
    new Users(4,"Costa",Job.Driver),
    new Users(5,"Vinicius",Job.Youtuber)
};
```
---
## Select
- We can Select any attribute of the list, array...
```C#
//Select the name of the users
var names = list.Select(Temp => Temp.Name);
```
<p align="center">
    <img width="33%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img8.png"> 
</p>


```C#
//Select more than one attribute
var namesAndJob = list.Select(Temp => new
{
    Temp.Name,
    Temp.Job
});
```
<p align="center">
    <img width="33%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img9.png"> 
</p>

## OrderBy


- OrderBy Job
    - We can Order a list with any attribute of a class;

```C#
//Order the list by Job
list = list.OrderBy(Temp => Temp.Job).ToList();
```
<p align="center">
    <img width="33%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img1.png"> 
</p>
	
- Order Descending by Job
```C#
\\Order Descending the list by job
list = list.OrderByDescending(Temp => Temp.Job).ToList();
```
<p align="center">
    <img width="33%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img2.png"> 
</p>
	
- Order Descending by Job and Ordered by Name
```C#
\\When we have two or more entities with the same "name" the LINQ will order these two or more by the second OrderBy.
list = list.OrderByDescending(Temp => Temp.Job).ThenBy(Temp => Temp.Name).ToList();
```
	
<p align="center">
    <img width="33%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img3.png"> 
</p>

## Where
	
```C#
\\Where (Users with Id >= 3)
list = list.Where(Temp => Temp.Id >= 3).ToList();
```
	
<p align="center">
    <img width="33%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img4.png"> 
</p>

```C#
\\Search for the id >= 3 and his job is a developer
list = list.Where(Temp => Temp.Id >= 3 && Temp.Job == Job.Developer).ToList();
```
	
<p align="center">
    <img width="33%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img10.png"> 
</p>

## Sum
- Sum a specific collumn and return the result
```C#
\\Sum of the IDs of the Users
int idSum = list.Sum(Temp => Temp.Id);
```
<p align="center">
    <img width="33%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img6.png"> 
</p>

```C#
\\Sum of the IDs of the Users where the ID >= 3
idSum = list.Where(Temp => Temp.Id >= 3).Sum(Temp => Temp.Id);
```
<p align="center">
    <img width="33%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img7.png"> 
</p>

## Any
- Search in the list if there ara at least one user that match the condicion
```C#
\\Any User with Id > 3
var r = list.Any(Temp => Temp.Id > 3);
```

<p align="center">
    <img width="33%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img11.png"> 
</p>

```C#
\\Exist some user with Id > 9
r = list.Any(Temp => Temp.Id > 9);
```
<p align="center">
    <img width="70%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img12.png"> 
</p>

## Contains
- Return true or false if a specific user it is in the list
```C#
Users usr = list.First(Temp => Temp.Id == 1);
r = list.Contains(usr);
```

<p align="center">
    <img width="70%" height="50px" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img13.png"> 
</p>

```C#
usr = new Users(10, "example", Job.Youtuber);
r = list.Contains(usr);
```

<p align="center">
    <img width="70%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img14.png"> 
</p>

## All
- Verify if all users in the list match with a specific condicion
	
```C#
\\Verify if all users match with the condition (name != hello)
r = list.All(Temp => Temp.Name != "hello");
```

<p align="center">
    <img width="70%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img15.png"> 
</p>

```C#
\\Verify if all users match with the condition (Id == 1)
r = list.All(Temp => Temp.Id == 1);
```

<p align="center">
    <img width="70%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img16.png"> 
</p>

## Min and Max
- Min
	- Min select the min value in a list of elements
```C#
\\The min ID found in the list
var min = list.Min(Temp => Temp.Id);
```
	
- Max
	- Max select the max value in a list of elements
	
```C#
\\The max ID found in the list
var max = list.Max(Temp => Temp.Id);
```
	
<p align="center">
    <img width="70%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img17.png"> 
</p>

## Distinct

- The names distinct
	- Return The list of Users with Names distinct
	
```C#
List<string> distintic = list.Select(Temp => Temp.Name).Distinct().ToList();
```
	
<p align="center">
    <img width="70%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img18.png"> 
</p>
	
	- We can use the distinct with any attribute in a class or element
	- Return The list of Users with jobs distinct
	
```C#
List<Job>  distinticJob = list.Select(Temp => Temp.Job).Distinct().ToList();
```
	
<p align="center">
    <img width="70%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img19.png"> 
</p>

## Take and TakeWhile

- Take 
	- Take the quantity of users (or elements in a list)
	
```C#
\\if we put list.Take(3) the LINQ will return the first three users
var take = list.Take(3);
```
	
<p align="center">
    <img width="70%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img20.png"> 
</p>
	
- TakeWhile
	-  The TakeWhile takes the Users while the condition is "True" 
	
```C#
\\Temp => Temp.Id < 3
var takeWhile = list.TakeWhile(Temp => Temp.Id < 3);     
```

<p align="center">
    <img width="70%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img21.png"> 
</p>


## First and FirstOrDefault

- First get the first element in the list
```C#
//Return the first element with any paraments
Users first = list.First();
```

- FirstOrDefault get the first element in the list but if dont fould anything
return null
```C#
//Return the first element with the argument "Temp => Temp.Name == "hello""
first = list.FirstOrDefault(Temp => Temp.Name == "hello");
              
```
<p align="center">
    <img width="70%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img22.png"> 
</p>

## Last and LastOrDefault

- Last get the last element in the list
```C#
\\Return the last element with any paraments
 Users last = list.Last();
```

- LastOrDefault get the last element in the list but if dont fould anything
return null

```C#
//Return the last element with the parament "Temp => Temp.Name == "hello""
last = list.LastOrDefault(Temp => Temp.Name == "hello");
```
<p align="center">
    <img width="70%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img23.png"> 
</p>

## SequenceEqual

- SequenceEqual
    - Return bool, if the seguence is equal return true
    - Verify if the list in this and the list in the parament is equal

```C#
// Verify if the same list is equal
bool sequence = list.SequenceEqual(list);
```

```C#
// Verify if the list and the list ordered by name is the same
sequence = list.SequenceEqual(list.OrderBy(Temp => Temp.Name));
```
```C#
// Verify if the list and the list ordered by Job is the same
sequence = list.SequenceEqual(list.OrderBy(Temp => Temp.Job));
```
<p align="center">
    <img width="70%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img24.png"> 
</p>

`
Credits: Vinícius Costa 
`
