import { Box, Typography, Button } from "@mui/material";
import StarWarsCharacters from "../../components/starWarsCharacters";
import { useNavigate } from "react-router-dom";

const Landing = () => {
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
        <Typography variant="h3">Welcome</Typography>
        <Typography variant="p">
          Check out the StarWars characters below
        </Typography>
        <Box display="flex" justifyContent="center" mt="20px">
          <Button
            onClick={() => navigate("/characters/search")}
            color="primary"
            variant="contained"
          >
            Search Characters
          </Button>
        </Box>
      </Box>

      <Box mt={5}>
        <StarWarsCharacters />
      </Box>
    </Box>
  );
};

export default Landing;
