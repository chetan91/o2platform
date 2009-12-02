// This file is part of the OWASP O2 Platform (http://www.owasp.org/index.php/OWASP_O2_Platform) and is released under the Apache 2.0 License (http://www.apache.org/licenses/LICENSE-2.0)
using O2.Kernel.Interfaces;
using O2.Kernel.Interfaces.O2Core;
using O2.Kernel.InterfacesBaseImpl;
using O2.Kernel.InterfacesBaseImpl;

namespace O2.Tool.ViewAssessmentRun
{
    class DI
    {
        public static IO2Log log = new KO2Log();
        public static IO2Config config = new KO2Config();
        public static IReflection reflection = new KReflection();
    }
}
