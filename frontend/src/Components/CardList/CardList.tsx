import { SyntheticEvent } from "react";
import { CompanySearch } from "../../companydates"
import Card from "../Card/Card"
import { v4 as uuidv4 } from 'uuid';


interface Props {
  searchResult: CompanySearch[];
  onPortfolioCreate: (e: SyntheticEvent) => void;
}

const CardList: React.FC<Props> = ({searchResult, onPortfolioCreate}: Props): JSX.Element => {
  return (
    <div>
      {searchResult.length > 0 ? (
      searchResult.map((result) => {
        return (
        <Card 
        id={result.symbol} 
        key={uuidv4()} 
        searchResult={result} 
        onPortfolioCreate={onPortfolioCreate}
        />)
      })
    ):(
    <p className="mb-3 mt-3 text-xl font-semibold text-center md:text-xl">
      No results!
    </p>
    )}
    </div>
  )
}
export default CardList;