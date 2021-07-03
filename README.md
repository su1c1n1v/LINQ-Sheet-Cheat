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
## OrderBy


- OrderBy Job
    - We can Order a list with any atribute of a class;

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
    <img width="33%" src="https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img5.png"> 
</p>

## Sum

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

`
Credits: Vinícius Costa 
`
