# **LINQ Sheet Cheat**

### In this project i will show how to work with LINQ
- To begin i create a class to use as a example and create a List<Users> to use the LINQ
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
<img src="~/img/img1.png"
     alt="Markdown Monster icon"
     style="float: left; margin-right: 10px;" />

- Order Descending by Job
```C#
\\Order Descending the list by job
list = list.OrderByDescending(Temp => Temp.Job).ToList();
```
<img src="~/img/img2.png"
     alt="Markdown Monster icon"
     style="float: left; margin-right: 10px;" />

- Order Descending by Job and Ordered by Name
```C#
\\When we have two or more entities with the same "name" the LINQ will order these two or more by the second OrderBy.
list = list.OrderByDescending(Temp => Temp.Job).ThenBy(Temp => Temp.Name).ToList();
```
<img src="~/img/img3.png"
     alt="Markdown Monster icon"
     style="float: left; margin-right: 10px;" />

## Where
```C#
\\Where (Users with Id >= 3)
list = list.Where(Temp => Temp.Id >= 3).ToList();
```
<img src="~/img/img4.png"
     alt="Markdown Monster icon"
     style="float: left; margin-right: 10px;" />

```C#
\\Search for the id >= 3 and his job is a developer
list = list.Where(Temp => Temp.Id >= 3 && Temp.Job == Job.Developer).ToList();
```
<img src="~/img/img5.png"
     alt="Markdown Monster icon"
     style="float: left; margin-right: 10px;" />

## Sum

```C#
\\Sum of the IDs of the Users
int idSum = list.Sum(Temp => Temp.Id);
```
![Alt Text](https://github.com/ved-suiciniv/Sheet-Cheat-LINQ/raw/master/img/img6.png)

```C#
\\Sum of the IDs of the Users where the ID >= 3
idSum = list.Where(Temp => Temp.Id >= 3).Sum(Temp => Temp.Id);
```
<img src="~/img/img7.png"
     alt="Markdown Monster icon"
     style="float: left; margin-right: 10px;" />

`
Credits: Vinícius Costa 
`
