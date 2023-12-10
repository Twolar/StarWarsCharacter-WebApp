import { Box, Typography, Button } from "@mui/material";
import StarWarsCharacterSearch from "../../components/StarWarsCharacterSearch";
import { useNavigate } from "react-router-dom";

const CharacterSearch = () => {
  const navigate = useNavigate();

  return (
    <Box
      m="0px 20px"
      display="flex"
      flexDirection="column"
      justifyContent="center"
      alignItems="center"
    >
      <Box textAlign="center">
        <Typography variant="h3">Character Search</Typography>
        <Typography variant="p">
          Search for a character by name in the box below
        </Typography>
      </Box>
      <Box mt={5}>
        <StarWarsCharacterSearch />
      </Box>
    </Box>
  );
};

export default CharacterSearch;
