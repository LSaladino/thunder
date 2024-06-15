using Bogus;
using Shared.Modelviews.ManTask;

namespace FakeData.ManTaskData
{
    public class ManTaskViewFaker : Faker<ManTaskView>
    {
        public ManTaskViewFaker()
        {
            var id = new Faker().Random.Number(1, 999999);
            RuleFor(x => x.Id, df => id);
            RuleFor(x => x.Description, df => df.Commerce.ProductDescription());
            RuleFor(x => x.CollaboratorName, df => df.Person.FullName);
            RuleFor(x => x.Comments, df => df.Company.CompanyName());
            RuleFor(x => x.StartDate, df => df.Date.Past());
            RuleFor(x => x.EndDate, df => df.Date.Past());
        }
    }
}
