import { Box, Typography, Card, CardContent, Button } from "@mui/material";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import axios from "../../api/axios";

const CharacterProfile = () => {
  let { characterId } = useParams();
  let navigate = useNavigate();
  const [isLoading, setIsLoading] = useState(true);
  const [isApiError, setIsApiError] = useState(false);
  const [character, setCharacter] = useState({});

  useEffect(() => {
    const getCharacter = async () => {
      try {
        const response = await axios.get(`/characters/${characterId}`);
        console.log(response.data);
        setCharacter(response?.data);
        setIsLoading(false);
        setIsApiError(false);
      } catch (err) {
        setIsLoading(false);
        setIsApiError(true);
        console.error(err);
      }
    };

    getCharacter();
  }, [characterId]);

  return (
    <Box
      m="0px 20px"
      display="flex"
      flexDirection="column"
      justifyContent="center"
      alignItems="center"
    >
      <Box textAlign="center">
        {isLoading ? (
          <>Loading...</>
        ) : !isApiError ? (
          <>
            <Typography variant="h3">{character.name}</Typography>
            <Card
              sx={{
                display: "flex",
                flexDirection: "column",
                height: "100%",
                minWidth: "500px",
                marginTop: "10px",
              }}
            >
              <CardContent>
                <Typography color="text.secondary">
                  Birth Year: {character.birthYear}
                </Typography>
                <Typography color="text.secondary">
                  Eye Color: {character.eyeColor}
                </Typography>
                <Typography color="text.secondary">
                  Height: {character.height}
                </Typography>
                <Typography color="text.secondary">
                  Mass: {character.mass}
                </Typography>
                <Typography color="text.secondary">
                  Skin Color: {character.skinColor}
                </Typography>
                <Typography color="text.secondary">
                  Gender: {character.gender}
                </Typography>
                <Typography color="text.secondary">
                  Hair Color: {character.hairColor}
                </Typography>
              </CardContent>
            </Card>
          </>
        ) : (
          <>Sorry this character does not exist, or there was an error.</>
        )}
      </Box>
      <Box display="flex" justifyContent="start" mt="20px">
        <Button
          onClick={() => navigate("/characters")}
          color="secondary"
          variant="contained"
        >
          See all characters
        </Button>
      </Box>
    </Box>
  );
};

export default CharacterProfile;
