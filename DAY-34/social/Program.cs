using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public string Name { get; }

    private List<Person> friends = new List<Person>();
    public IReadOnlyList<Person> Friends => friends.AsReadOnly();

    public Person(string name)
    {
        Name = name;
    }

    public void AddFriend(Person friend)
    {
        if (friend == null || friend == this)
            return;

        if (!friends.Contains(friend))
        {
            friends.Add(friend);
            friend.AddFriend(this);
        }
    }
}

public class SocialNetwork
{
    private List<Person> members = new List<Person>();

    public void AddMember(Person person)
    {
        members.Add(person);
    }

    public void ShowNetwork()
    {
        foreach (var person in members)
        {
            string friendNames = string.Join(", ",
                person.Friends.Select(f => f.Name));

            Console.WriteLine($"{person.Name}: {friendNames}");
        }
    }
}