import { Box, InputBase, IconButton } from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import { useState } from "react";

const StarWarsCharacterSearch = () => {
  const [searchValue, setSearchValue] = useState("");
  const [characters, setCharacters] = useState([]);

  const handleSearchChange = (e) => {
    setSearchValue(e.target.value);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log("We are going to search for: " + searchValue);
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
    </Box>
  );
};

export default StarWarsCharacterSearch;
