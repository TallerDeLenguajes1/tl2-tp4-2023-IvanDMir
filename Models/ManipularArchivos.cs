using System.Text.Json;
using Programa;

namespace ACCESOADATOS {

    public abstract class AccesoADatos {
        public abstract List<Cadete> LeerArchivoDeCadetes(string nombreArchivo);
        public abstract List<Cadeteria> LeerArchivoDeCadeteria(string nombreArchivo,List<Cadete> ListaCadetes);
    public void CrearArchivoJSON(string ruta){
        var archivoCSV = new List<string[]>();
        var Linea = File.ReadAllLines(ruta);
        foreach(string line in Linea.Skip(1)){
            archivoCSV.Add(line.Split(','));   
        }
        var propiedades = Linea[0].Split(',');
        var ListaObjetos = new List<Dictionary<string,string>>();
        for(int i =0; i <Linea.Length; i++ ){
            var Objeto = new Dictionary<string,string>();
            for (int j=0;j<propiedades.Length; j++){
                Objeto.Add(propiedades[j],archivoCSV[i][j]);
            }
            ListaObjetos.Add(Objeto);
        }
        var ArchivoJSON =JsonSerializer.Serialize(ListaObjetos,new JsonSerializerOptions{ WriteIndented = true});
        File.WriteAllText($"{ruta.Split('.')[0]}.json",ArchivoJSON);
    }
 /*   public class ArchivosCSV : Manipular {
        private List<string[]> LecturaCsv(string nombreArchivo){
            var Lectura = new List<string[]> ();
            if (File.Exists(nombreArchivo)){
                var archivo = new FileStream(nombreArchivo,FileMode.Open);
                var strReader = new StreamReader(archivo);
                var linea = "";
                while ((linea = strReader.ReadLine()) != null){
                        string[] arrayLine = linea.Split(',');
                        Lectura.Add(arrayLine);
                }
                strReader.Close();
            }else {
                return null;
            }
            return Lectura;
        }
        public override List<Cadete> LeerArchivoDeCadetes(string nombreArchivo)
        {
            var listaCsv = this.LecturaCsv(nombreArchivo);
            var Lista = new List<Cadete> ();
            if (listaCsv != null){
                int id = 0;
                foreach (var Cadete in listaCsv){
                    if (Cadete == null){
                        break;
                    }
                    var nuevoCadete = new Cadete(id,Cadete[0],Cadete[1],Cadete[2]);
                    Lista.Add(nuevoCadete);
                    id += 1;
                }
            }
            else {
               return null;
            }
            return Lista;
        }
         public override List<Cadeteria> LeerArchivoDeCadeteria(string nombreArchivo,List<Cadete> ListaCadetes)
        {
            var listaCsv = Archivos.Leer(nombreArchivo);
            var Lista = new List<Cadeteria> ();
            if (listaCsv != null){
                foreach (var Cadeteria in listaCsv){
                    if (Cadeteria == null){
                        break;
                    }
                    var nuevaCadeteria = new Cadeteria(Cadeteria[0],Cadeteria[1],ListaCadetes);
                    Lista.Add(nuevaCadeteria);
                  
                }
            }
            return Lista;
            }
          
        }*/

        public class ManipulacionJSON : AccesoADatos {
        public override List<Cadete> LeerArchivoDeCadetes(string nombreArchivo)
        {
            List<Cadete> ListaCadetes;
            string Archivo = "";
            using ( var AbrirArchivo = new FileStream(nombreArchivo,FileMode.Open)){
                using (var strReader = new StreamReader(AbrirArchivo)){
                    Archivo = strReader.ReadToEnd();
                    AbrirArchivo.Close();
                }
            ListaCadetes = JsonSerializer.Deserialize<List<Cadete>>(Archivo);
            }
            return ListaCadetes;
        }
         public override List<Cadeteria>LeerArchivoDeCadeteria(string rutaDeArchivo, List<Cadete> ListaCadetes){
            List<Cadeteria>listaCadeteria;
            string documento;
            using (var archivoOpen = new FileStream(rutaDeArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    documento = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
                listaCadeteria = JsonSerializer.Deserialize<List<Cadeteria>>(documento);
                if(listaCadeteria!=null)
                {
                    foreach (var Cadetes in listaCadeteria)
                {
                    Cadetes.ListadoCadetes.AddRange(ListaCadetes);
                }
                }
                
            }
            return (listaCadeteria);
        }
    }

    }
    }
