import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { CompanyProfile } from "../../companydates";
import { Get_company_info } from "../../api";
import SideBar from "../../Components/SideBar/SideBar";
import CompanyDashboard from "../../Components/CompanyDashboard/CompanyDashboard";
import Mosaics from "../../Components/Mosaics/Mosaics";
import TenKFinder from "../../Components/TenKFinder/TenKFinder";

interface Props {
    
}

const CompanyPage = (props: Props) => {

    let { ticker } = useParams<string>();
    const [company, setCompany] = useState<CompanyProfile>();
  
    useEffect(() => {

      const getProfileInit = async () => {
        const result = await Get_company_info(ticker!);
        setCompany(result?.data[0]);
      };

      getProfileInit();
    },[])
 
  return (
    <> 
    {company ?  (
      <div className="w-full relative flex ct-docs-disable-sidebar-content overflow-x-hidden">

        <SideBar />

        <CompanyDashboard ticker={ticker!}>

            <Mosaics title="Company Name" content={company.companyName} />
            <Mosaics title="Price" content={"$" + company.price.toString()} />
            <Mosaics title="DCF" content={"$" + company.dcf.toString()} />
            <Mosaics title="Sector" content={company.sector} />

            <TenKFinder ticker={ticker!}/>
 
        </CompanyDashboard>
        
      </div>
      
        ): (
      <div>company not found!</div>
    )}
    </>
  )
}
export default CompanyPage           