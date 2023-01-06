using WebAPI_.Drivers;
using NUnit.Framework;

namespace WebAPI_.StepDefinitions
{

    [Binding]
    public class UploadMetadataDeleteStepDefinitions
    {
        [Given(@"folder ""([^""]*)"" exists")]
        public void GivenEmptyFolderExists(string folder)
        {
            DropBoxDriver driver = DropBoxDriver.GetInstance();
            driver.Folder = folder;
        }

        [When(@"upload file ""([^""]*)""")]
        async public void WhenUploadFile(string filename)
        {
            DropBoxDriver driver = DropBoxDriver.GetInstance();
            var response = driver.UploadFile(filename);
            response.Wait();
            var metadata = response.Result;
            Assert.IsTrue(metadata.IsSuccessful);
        }

        [When(@"get metadata of ""([^""]*)""")]
        async public void GetMetadataOf(string filename)
        {
            DropBoxDriver driver = DropBoxDriver.GetInstance();
            var resp = driver.GetMetadata(filename);
            resp.Wait();
            var metadata = resp.Result;
            Assert.IsTrue(metadata.IsSuccessful);
        }

        [When(@"delete ""([^""]*)""")]
        async public void Delete(string filename)
        {
            DropBoxDriver driver = DropBoxDriver.GetInstance();
            var resp = driver.DeleteFile(filename);
            resp.Wait();
            var metadata = resp.Result;
            Assert.IsTrue(metadata.IsSuccessful);
        }
    }
}
