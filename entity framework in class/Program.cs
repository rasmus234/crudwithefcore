using entity_framework_in_class;


var member = new Member()
{
    MemberName = "Rasmus Hansen 2",
};
var crud = new CRUD();

crud.CreateMember(member);
var memberFromDb = crud.GetMember("Rasmus Hansen 2");
Console.Out.WriteLine(memberFromDb.MemberId);

crud.DeleteMember("Rasmus Hansen 2");
var memberFromDb2 = crud.GetMember("Rasmus Hansen 2");
Console.Out.WriteLine(memberFromDb2.MemberName);