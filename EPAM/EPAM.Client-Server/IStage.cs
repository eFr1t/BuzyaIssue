using EPAM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Client_Server
{
    public interface IStage
    {
        bool CreateStage(Stage stage);
        bool DeleteStage(Stage stage);
    }
}
