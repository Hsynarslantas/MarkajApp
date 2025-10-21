﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApps.DtoLayer.Dtos.AIDtos
{
    public class GeminiCommentDto
    {
        public class Rootobject
        {
            public Candidate[] candidates { get; set; }
            public Usagemetadata usageMetadata { get; set; }
            public string modelVersion { get; set; }
            public string responseId { get; set; }
        }

        public class Usagemetadata
        {
            public int promptTokenCount { get; set; }
            public int candidatesTokenCount { get; set; }
            public int totalTokenCount { get; set; }
            public Prompttokensdetail[] promptTokensDetails { get; set; }
            public Candidatestokensdetail[] candidatesTokensDetails { get; set; }
        }

        public class Prompttokensdetail
        {
            public string modality { get; set; }
            public int tokenCount { get; set; }
        }

        public class Candidatestokensdetail
        {
            public string modality { get; set; }
            public int tokenCount { get; set; }
        }

        public class Candidate
        {
            public Content content { get; set; }
            public string finishReason { get; set; }
            public float avgLogprobs { get; set; }
        }

        public class Content
        {
            public Part[] parts { get; set; }
            public string role { get; set; }
        }

        public class Part
        {
            public string text { get; set; }
        }
    }
}
