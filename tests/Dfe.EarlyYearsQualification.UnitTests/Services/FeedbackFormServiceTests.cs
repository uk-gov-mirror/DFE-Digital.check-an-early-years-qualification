using Contentful.Core.Models;
using Dfe.EarlyYearsQualification.Content.Constants;
using Dfe.EarlyYearsQualification.Content.Entities;
using Dfe.EarlyYearsQualification.Web.Models.Content;
using Dfe.EarlyYearsQualification.Web.Services.FeedbackForm;

namespace Dfe.EarlyYearsQualification.UnitTests.Services;

[TestClass]
public class FeedbackFormServiceTests
{
    [TestMethod]
    public void ConvertQuestionListToString_PassInModel_ReturnsExpectedResult()
    {
        const string question = "Question";
        const string answer = "Answer";
        const string additionalInfo = "AdditionalInfo";

        const string expectedResult = $"""
            ## {question}
            {answer}
            {additionalInfo}
            
            ---
            
            """;
        
        var model = new FeedbackFormPageModel
                    {
                        Heading = "",
                        CtaButtonText = "",
                        ErrorBannerHeading = "",
                        QuestionList =
                        [
                            new FeedbackFormQuestionListModel
                            {
                                Question = question,
                                Answer = answer,
                                AdditionalInfo = additionalInfo
                            }
                        ]
                    };
        var service = new FeedbackFormService();
        var result = service.ConvertQuestionListToString(model);
        result.Should().NotBeNull();
        result.Should().Match(expectedResult);
    }
    
    [TestMethod]
    public void ConvertQuestionListToString_NoAdditionalInfo_ReturnsExpectedResult()
    {
        const string question = "Question";
        const string answer = "Answer";

        const string expectedResult = $"""
            ## {question}
            {answer}
            
            ---
            
            """;
        
        var model = new FeedbackFormPageModel
                    {
                        Heading = "",
                        CtaButtonText = "",
                        ErrorBannerHeading = "",
                        QuestionList =
                        [
                            new FeedbackFormQuestionListModel
                            {
                                Question = question,
                                Answer = answer
                            }
                        ]
                    };
        var service = new FeedbackFormService();
        var result = service.ConvertQuestionListToString(model);
        result.Should().NotBeNull();
        result.Should().Match(expectedResult);
    }
}