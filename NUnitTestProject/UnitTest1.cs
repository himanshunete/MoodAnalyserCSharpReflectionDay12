using NUnit.Framework;
using MoodAnalyserAppWithCore;


namespace NUnitTestProject
{

    public class Tests
    {

        MoodAnalyserFactory moodAnalyserFactory;
        [SetUp]
        public void Setup()
        {
            moodAnalyserFactory = new MoodAnalyserFactory();

        }

        /// <summary>
        /// TC-4.1 Given MoodAnalyse Class Name Should Return MoodAnalyser Object
        /// </summary>
        [Test]
        public void MoodAnalyserClassName_ShouldReturnMoodAnalyserObject()
        {
            string message = null;
            object expected = new MoodAnalyser(message);
            object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyserAppWithCore.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);            
        }

        /// <summary>
        /// TC-4.2 Given MoodAnalyse Class Name When Improper Should Throw Exception
        /// </summary>
        [Test]
        public void MoodAnalyserClassName_WhenImproper_ShouldThrowMoodAnalyserException()
        {
            object obj=null;
            string message = null;
            string expected = "Class not found";
            try
            {
                obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyserAppWithCore.Mood", "Mood");
            }
            catch(MoodAnalyserCustomException exception) 
            {
                Assert.AreEqual(expected, exception.Message);
            } 
        }

        /// <summary>
        /// TC-4.3 Given MoodAnalyse Class Name When Constructor is Improper Should Throw Exception
        /// </summary>
        [Test]
        public void MoodAnalyserClassName_WhenConstructorIsImproper_ShouldThrowMoodAnalyserException()
        {
            object obj = null;
            string message = null;
            string expected = "Method not found";
            try
            {
                obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyserAppWithCore.MoodAnalyser", "AnalyserMood");
            }
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }





    }
}