import { Box, Typography, Button } from "@mui/material";
import StarWarsCharacters from "../../components/StarWarsCharacters";
import { useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import axios from "../../api/axios";

const Characters = () => {
  const navigate = useNavigate();
  const [isLoading, setIsLoading] = useState(true);
  const [isApiError, setIsApiError] = useState(false);
  const [characters, setCharacters] = useState([]);

  useEffect(() => {
    const getCharacters = async () => {
      try {
        const response = await axios.get("/characters");
        setCharacters(response?.data);
        setIsLoading(false);
        setIsApiError(false);
      } catch (err) {
        setIsApiError(true);
        setIsLoading(false);
        console.error(err);
      }
    };

    getCharacters();
  }, []);

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
        {isLoading ? (
          <>Searching...</>
        ) : isApiError ? (
          <>Oops, looks like there was an error.</>
        ) : (
          <StarWarsCharacters characters={characters} />
        )}
      </Box>
    </Box>
  );
};

export default Characters;
