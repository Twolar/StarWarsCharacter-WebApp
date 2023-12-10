import { Box, InputBase, IconButton } from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import { useState } from "react";
import axios from "../api/axios";
import StarWarsCharacters from "./StarWarsCharacters";

const StarWarsCharacterSearch = () => {
  const [searchValue, setSearchValue] = useState("");
  const [isSearching, setIsSearching] = useState(false);
  const [hasSearched, setHasSearched] = useState(false);
  const [isApiError, setIsApiError] = useState(false);
  const [characters, setCharacters] = useState([]);

  const searchCharacters = async (searchValue) => {
    setHasSearched(true);
    try {
      const response = await axios.post(
        "/characters/search",
        JSON.stringify({
          SearchValue: searchValue,
        }),
        {
          headers: { "Content-Type": "application/json" },
        }
      );
      setCharacters(response?.data);
      setIsSearching(false);
      setIsApiError(false);
    } catch (err) {
      setIsApiError(true);
      setIsSearching(false);
      console.error(err);
    }
  };

  const handleSearchChange = (e) => {
    setSearchValue(e.target.value);
  };

  const handleSubmit = (e) => {
    console.log("Searching for: " + searchValue);
    e.preventDefault();
    setIsSearching(true);
    searchCharacters(searchValue);
  };

  return (
    <Box height="100%">
      <form onSubmit={handleSubmit}>
        <Box display="flex" borderRadius="3px" border="solid 1px white">
          <InputBase
            placeholder="Search for character..."
            value={searchValue}
            onChange={handleSearchChange}
            sx={{ ml: 2, flex: 1, color: "white" }}
          />
          <IconButton type="submit" sx={{ p: 1, color: "white" }}>
            <SearchIcon />
          </IconButton>
        </Box>
      </form>

      <Box mt={5}>
        {isSearching ? (
          <>Searching...</>
        ) : isApiError ? (
          <>Oops, looks like there was an error.</>
        ) : hasSearched && characters < 1 ? (
          <>Nothing here...</>
        ) : (
          <StarWarsCharacters characters={characters} />
        )}
      </Box>
    </Box>
  );
};

export default StarWarsCharacterSearch;
