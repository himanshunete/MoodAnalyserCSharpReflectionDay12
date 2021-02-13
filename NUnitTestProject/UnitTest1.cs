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
            string expected = "Class not found";
            try
            {
                object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyserAppWithCore.Mood", "Mood");
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


        /// <summary>
        /// TC-5.1  Given MoodAnalyse Class Name Should Return MoodAnalyser Object
        /// </summary>
        [Test]
        public void MoodAnalyserClassName_ShouldReturnMoodAnalyserObject_UsingParametrizedConstructor()
        {
            object expected = new MoodAnalyser("HAPPY");
            object obj = MoodAnalyserFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyserAppWithCore.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }

        /// <summary>
        /// TC-5.2  Given MoodAnalyse Class Name When Improper Should Throw Exception
        /// </summary>
        [Test]
        public void MoodAnalyserClassName_WhenImproper_UsingParametrizedConstructor_ShouldThrowExcpetion()
        {
            string expected = "Class not found";
            try
            {
                object obj = MoodAnalyserFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyserAppWithCore.Mood", "MoodAnalyser");
            }
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        /// <summary>
        /// TC-5.3  Given MoodAnalyse Class Name When Constructor is Improper Should Throw Exception
        /// </summary>
        [Test]
        public void MoodAnalyserClassName_WhenConstructorIsImproper_UsingParametrizedConstructor_ShouldThrowExcpetion()
        {
            string expected = "Method not found";
            try
            {
                object obj = MoodAnalyserFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyserAppWithCore.MoodAnalyser", "Mood");
            }
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        /// <summary>
        /// TC-6.1  Given Happy Message Using Using Reflector When Proper Should Return Hppy Name Should Return MoodAnalyser Object
        /// </summary>
        [Test]
        public void GivenHppyMessge_WhenProper_ShouldReturnHppy()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyserFactory.InvokeAnalyseMood("HAPPY", "AnalyserMood");
            Assert.AreEqual(expected, mood);
        }

        /// <summary>
        /// TC-6.2  Given Happy Message Using Using Reflector When ImProper Method Should Return Hppy Name Should Throw Exception
        /// </summary>
        [Test]
        public void GivenHppyMessge_WhenIMProperMethod_ShouldThrowException()
        {
            string expected = "Method not found";
            try
            {
                string mood = MoodAnalyserFactory.InvokeAnalyseMood("HAPPY", "Analyser");
            }
            catch(MoodAnalyserCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        /// <summary>
        /// TC-7.1  Given Hppy Should Return Hppy
        /// </summary>
        [Test]
        public void Given_HAPPYMessage_WithReflector_Should_ReturnHAPPY()
        {
            string result = MoodAnalyserFactory.SetField("HAPPY", "message");
            Assert.AreEqual("HAPPY", result);
        }

        /// <summary>
        /// TC-7.2  Set Field When Improper Should Throw Exception 
        /// </summary>
        [Test]
        public void SetField_WhenImProper_ShouldThrowException()
        {
            try
            {
                string result = MoodAnalyserFactory.SetField("HAPPY", "me");
            }
            catch(MoodAnalyserCustomException exception)
            {
                Assert.AreEqual("Field is not found", exception.Message);
            }
        }

        /// <summary>
        /// TC-7.3  Set Null Messge  Should Throw Exception 
        /// </summary>
        [Test]
        public void SettingNullMessge_ShouldThrowException()
        {
            try
            {
                string result = MoodAnalyserFactory.SetField(null, "message");
            }
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual("Message should not be null", exception.Message);
            }
        }





























    }
}