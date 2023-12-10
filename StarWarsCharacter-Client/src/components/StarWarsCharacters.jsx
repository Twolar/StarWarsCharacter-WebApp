import { useEffect, useState } from "react";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import Typography from "@mui/material/Typography";
import { Box, CardActionArea, Grid } from "@mui/material";
import { useNavigate } from "react-router-dom";
import axios from "../api/axios";

const StarWarsCharacters = () => {
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
    <Box maxWidth={750}>
      {isLoading ? (
        <>Loading...</>
      ) : !isApiError ? (
        <>
          <Grid
            container
            rowSpacing={1}
            columnSpacing={{ xs: 1, sm: 2, md: 3 }}
          >
            {characters.map((character) => (
              <Grid item xs={12} sm={6} md={6} key={character.id}>
                <Card
                  sx={{
                    display: "flex",
                    flexDirection: "column",
                    height: "100%",
                  }}
                >
                  <CardActionArea
                    sx={{ height: "100%" }}
                    onClick={() => navigate(`/characters/${character.id}`)}
                  >
                    <CardContent>
                      <Typography gutterBottom variant="h6" component="div">
                        {character.name}
                      </Typography>
                    </CardContent>
                  </CardActionArea>
                </Card>
              </Grid>
            ))}
          </Grid>
        </>
      ) : (
        <>Oops, looks like an error was encountered.</>
      )}
    </Box>
  );
};

export default StarWarsCharacters;
