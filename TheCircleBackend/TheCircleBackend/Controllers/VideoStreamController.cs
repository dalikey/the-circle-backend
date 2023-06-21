﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheCircleBackend.Domain.DTO;
using TheCircleBackend.Domain.DTO.EncryptedPayload;
using TheCircleBackend.DomainServices.IHelpers;
using TheCircleBackend.DomainServices.IRepo;

namespace TheCircleBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoStreamController : ControllerBase
    {
        private readonly ISecurityService securityService;
        private readonly IVidStreamRepo VidStreamRepo;
        private readonly IWebsiteUserRepo websiteUserRepo;

        public VideoStreamController(ISecurityService securityService, IVidStreamRepo vidStreamRepo, IWebsiteUserRepo websiteUserRepo)
        {
            this.securityService = securityService;
            VidStreamRepo = vidStreamRepo;
            this.websiteUserRepo = websiteUserRepo;
        }

        [HttpGet("{hostId}")]
        public IActionResult Get(int hostId)
        {
            //Get videostream
            Domain.Models.Stream? VideoStream = VidStreamRepo.GetCurrentStream(hostId);
            //Server keypair
            var ServerKeys = securityService.GetServerKeys();

            if(VideoStream == null)
            {
                var sign = securityService.SignData("Geen runnende stream aanwezig", ServerKeys.privKey);
                var DTO = new
                {
                    Signature = sign,
                    OriginalData = "Geen runnende stream aanwezig"
                };
                return BadRequest(DTO);
            }

            var VidStreamDTO = new VideoStreamDTO()
            {
                id = 0,
                endStream = null,
                startStream = new DateTime(),
                transparantUserId = hostId,
                title = VideoStream.Title
            };

            var Signature = securityService.SignData(VidStreamDTO, ServerKeys.privKey);

            var streamInfoPackage = new VidStreamDTO()
            {
                OriginalData = VidStreamDTO,
                Signature = Signature,
                RandomId = Guid.NewGuid().ToString()
            };
            return Ok(streamInfoPackage);
        }

        [HttpPost]
        public  IActionResult Post(VidStreamDTO videoStreamDTO)
        {
            //Get userId keys
            var KeyPair = securityService.GetKeys(videoStreamDTO.SenderUserId);
            //check integrity
            var isValid = securityService.HoldsIntegrity(videoStreamDTO.OriginalData, videoStreamDTO.Signature, KeyPair.pubKey);
            //server keys
            var ServerKeys = securityService.GetServerKeys();
            if(isValid)
            {
                VidStreamRepo.StartStream(videoStreamDTO.OriginalData.transparantUserId, videoStreamDTO.OriginalData.title);

                websiteUserRepo.SetUserOnline(videoStreamDTO.OriginalData.transparantUserId);

                var latestStream = VidStreamRepo.GetCurrentStream(videoStreamDTO.OriginalData.transparantUserId);
                //Succes response
                var succes = new
                {
                    streamId = latestStream.Id
                };
                var signatureSucces = securityService.SignData(succes, ServerKeys.privKey);
                var succesDTO = new
                {
                    Signature = signatureSucces,
                    OriginalData = succes,
                };
                return Ok(succesDTO);
            }


            //Fail response
            var fail = new
            {
                Message = "Data is niet integer"
            };

            var signatureOut = securityService.SignData(fail, ServerKeys.privKey);

            var failDTO = new
            {
                Signature = signatureOut,
                OriginalData = fail
            };
            return BadRequest(failDTO);
        }

        [HttpPut("{hostId}/CurrentStream/{streamId}")]
        public IActionResult Put(int hostId, int streamId)
        {
            //Server keys
            var ServerKeys = securityService.GetServerKeys();
           //Stream wordt gestopt
            VidStreamRepo.StopStream(hostId, streamId);

            //Succes response
            var succes = new
            {
                Message = "Data succesvol toegevoegd"
            };
            var signatureSucces = securityService.SignData(succes, ServerKeys.privKey);
            var succesDTO = new
            {
                Signature = signatureSucces,
                OriginalData = succes,
            };
            return Ok(succesDTO);
        }
    }
}
