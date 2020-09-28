using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using LeaseManagement.BusinessEntities.ViewModels;

namespace LeaseManagement.Tests
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() =>
            {
                var fixture = new Fixture().Customize(new AutoMoqCustomization());
                return fixture;
            })
        {
        }
    }
}