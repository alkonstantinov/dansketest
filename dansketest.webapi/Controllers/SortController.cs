using dansketest.webapi.bs.FileUitls;
using dansketest.webapi.bs.Sort;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dansketest.webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SortController : ControllerBase
    {
        private readonly ISorter[] _sorters;
        private readonly IFileTools _fileTools;
        public SortController(IEnumerable<ISorter> sorters, IFileTools fileTools)
        {
            _fileTools = fileTools;
            _sorters = sorters.ToArray();
        }

        [HttpGet("GetLastSortResult")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_fileTools.ReadFile());
            }
            catch (FileNotFoundException fnf)
            {
                return BadRequest(fnf.Message);
            }
            catch (UnauthorizedAccessException uae)
            {
                return Unauthorized(uae.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("Sort")]
        public IActionResult Sort([FromBody] string input)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                int[] sorted = null;
                Stopwatch stopWatch = new Stopwatch();
                foreach (var sorter in _sorters)
                {
                    stopWatch.Start();
                    sorted = sorter.Sort(input);
                    stopWatch.Stop();
                    sb.AppendLine($"{sorter.GetType()} took {stopWatch.ElapsedMilliseconds} miliseconds");
                }
                _fileTools.WriteToFile(string.Join(' ', sorted));
            }
            catch (ArgumentNullException ane)
            {
                return BadRequest(ane.Message);
            }
            catch (InvalidCastException ice)
            {
                return BadRequest(ice.Message);
            }
            catch (ArgumentOutOfRangeException aoe)
            {
                return BadRequest(aoe.Message);
            }
            catch (UnauthorizedAccessException uae)
            {
                return Unauthorized(uae.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return Ok(sb.ToString());
        }

    }
}
