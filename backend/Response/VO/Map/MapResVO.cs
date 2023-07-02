using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Response.VO.Map
{
    public class MapResVO
    {
        private string? _code;
        private string? _address;

        public string? Code { get => _code; set => _code = value; }
        public string? Address { get => _address; set => _address = value; }
    }
}