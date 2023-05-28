using Assets._scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using UnityEngine;
using UnityEngine.UI;
namespace Assets._scripts.Entities
{


    public class Navigated_Pannel: MonoBehaviour, Navigated_Panel_inteface
    {
        public Enums.Navs_Lanels _id;
     
        public Enums.Navs_Lanels ID { get => _id; set => _id = value; }

        public void Desactivate(bool hide=true)
        {
            gameObject.SetActive(!hide);
        }

        public void Update()
        {
            
        }
        private void Start()
        {
            
        }




    }
}
