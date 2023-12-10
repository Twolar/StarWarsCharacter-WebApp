import { Box, Typography } from "@mui/material";
import StarWarsCharacterSearch from "../../components/StarWarsCharacterSearch";

const CharacterSearch = () => {
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
      <Box mt={5} sx={{ width: { xs: "100%", sm: "85%", md: "75%" } }}>
        <StarWarsCharacterSearch />
      </Box>
    </Box>
  );
};

export default CharacterSearch;
