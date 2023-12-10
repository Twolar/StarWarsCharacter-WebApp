import { Box, Typography } from "@mui/material";
import StarWarsCharacters from "../../components/starWarsCharacters";

const Landing = () => {
  return (
    <Box
      m="0px 20px"
      display="flex"
      flexDirection="column"
      justifyContent="center"
      alignItems="center"
    >
      <Box textAlign="center">
        <Typography variant="h3">Welcome</Typography>
        <Typography variant="p">Check out the characters below</Typography>
      </Box>

      <Box mt={5}>
        <StarWarsCharacters />
      </Box>
    </Box>
  );
};

export default Landing;
