using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Compute;

namespace TestCompute
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputeServer.WebAddress = "http://localhost:8081";

            // Uses standard Rhino3dmIO methods locally to create a sphere.
            var sphere = new Rhino.Geometry.Sphere(Rhino.Geometry.Point3d.Origin, 12);
            var sphereAsBrep = sphere.ToBrep();

            // the following function calls compute.rhino3d.com to get access to something not
            // available in Rhino3dmIO. In this case send a Brep to Compute and get a Mesh back.
            var meshes = MeshCompute.CreateFromBrep(sphereAsBrep);

            // Use regular Rhino3dmIO local calls to count the vertices in the mesh.
            Console.WriteLine($"Got {meshes.Length} meshes");
            for (int i = 0; i < meshes.Length; i++)
            {
                Console.WriteLine($"  {i + 1} mesh has {meshes[i].Vertices.Count} vertices");
            }

            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
    }
}