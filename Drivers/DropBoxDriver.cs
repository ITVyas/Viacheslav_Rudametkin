using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dropbox.Api.Files;
using RestSharp;
using WebAPI_.DropboxData;



namespace WebAPI_.Drivers
{
    class DropBoxDriver
    {
        private RestClient _client;
        static private DropBoxDriver _instance = null;
        public string Folder { set; get; } = "";
        private DropBoxDriver()
        {
            _client = new RestClient(new RestClientOptions("https://content.dropboxapi.com/2"));
            _client.AddDefaultHeader("Authorization", "Bearer " + Tokens.AccessToken);
        }

        static public DropBoxDriver GetInstance()
        {
            if (_instance == null)
                _instance = new DropBoxDriver();
            return _instance;
        }

        private RestRequest _createRestUpdateRequest(string path, string file)
        {
            RestRequest rrq = new RestRequest(DropboxUrls.Upload, Method.Post);
            rrq.AddHeader("Dropbox-API-Arg", "{\"path\":\"/" + file + "\"}");
            rrq.AddHeader("Content-Type", "application/octet-stream");

            byte[] fileBytes = File.ReadAllBytes(path);
            rrq.AddParameter("application/octet-stream", fileBytes, ParameterType.RequestBody);

            return rrq;
        }

        private RestRequest _createRestMetadataRequest(string file)
        {
            RestRequest rrq = new RestRequest(DropboxUrls.Metadata, Method.Post);
            rrq.AddHeader("Content-Type", "application/json");
            rrq.AddJsonBody<object>(new { include_deleted = false, include_has_explicit_shared_members = false, include_media_info = false, path = file });

            return rrq;
        }

        private RestRequest _createRestDeleteRequest(string file)
        {
            RestRequest rrq = new RestRequest(DropboxUrls.Delete, Method.Post);
            rrq.AddHeader("Content-Type", "application/json");
            rrq.AddJsonBody<object>(new { path = file });

            return rrq;
        }
        public async Task<RestResponse<Metadata>> UploadFile(string file)
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, "files/file.txt");
            var request = _createRestUpdateRequest(path, file);
            var response = await _client.ExecutePostAsync<Metadata>(request);
            return response;
        }

        public async Task<RestResponse<Metadata>> GetMetadata(string file)
        {
            var request = _createRestMetadataRequest("/" + file);
            var response = await _client.ExecutePostAsync<Metadata>(request);
            return response;
        }

        public async Task<RestResponse<DeletedMetadata>> DeleteFile(string file)
        {
            var request = _createRestDeleteRequest("/" + file);
            var response = await _client.ExecutePostAsync<DeletedMetadata>(request);
            return response;
        }

    }
}
