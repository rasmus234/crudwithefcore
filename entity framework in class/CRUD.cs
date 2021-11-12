using Microsoft.EntityFrameworkCore;

namespace entity_framework_in_class;

public class CRUD
{
    public void ReadAllMembers()
    {
        using (var db = new MemberdbContext())
        {
            foreach (var member in db.Member)
            {
                Console.WriteLine(member.MemberName +" " + member.MemberId);
            }
        }
    }
    
    public void CreateMember(Member member)
    {
        using (var db = new MemberdbContext())
        {
            db.Member.Add(member);
            db.SaveChanges();
        }
    }
    
    public void UpdateMember(Member member)
    {
        using (var db = new MemberdbContext())
        {
            db.Entry(member).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
    
    public void UpdateMember(int id, string name)
    {
        using (var db = new MemberdbContext())
        {
            var member = db.Member.Find(id);
            member.MemberName = name;
            db.SaveChanges();
        }
    }
    
    public void DeleteMember(int id)
    {
        using (var db = new MemberdbContext())
        {
            var member = db.Member.Find(id);
            db.Member.Remove(member);
            db.SaveChanges();
        }
    }
    public void DeleteMember(string name)
    {
        using (var db = new MemberdbContext())
        {
            var member = db.Member.FirstOrDefault(m => m.MemberName == name);
            db.Member.Remove(member);
            db.SaveChanges();
        }
    }
    public void ReadMember(int id)
    {
        using (var db = new MemberdbContext())
        {
            var member = db.Member.Find(id);
            Console.WriteLine(member?.MemberName ?? "null");
        }
    }

    public Member GetMember(int id)
    {
        using (var db = new MemberdbContext())
        {
            return db.Member.Find(id);
        }
    }
    public Member GetMember(string name)
    {
        using (var db = new MemberdbContext())
        {
            return db.Member.FirstOrDefault(m => m.MemberName == name);
        }
    }
}