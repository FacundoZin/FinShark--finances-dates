import { CompanyTenK } from "../../companydates"
import { Link } from "react-router-dom"

type Props = {
    TenK: CompanyTenK
}
const TenKitem = ({TenK}: Props) => {

    const Fillingdata = new Date (TenK.fillingDate).getFullYear();

  return (
    <Link
    reloadDocument
    to={TenK.finalLink}
    type="button"
    className="inline-flex items-center px-4 py-2 text-sm font-medium text-white bg-Green-300 border border-gray-200 rounded-l-lg hover:bg-gray-100 hover:text-blue-700 focus:z-10 focus:ring-2 focus:ring-blue-700 focus:text-blue-700 dark:bg-gray-700 dark:border-gray-600 dark:text-white dark:hover:text-white dark:hover:bg-gray-600 dark:focus:ring-blue-500 dark:focus:text-white"
    >
        Report {TenK.symbol} {Fillingdata}
    </Link>
  )
}
export default TenKitem