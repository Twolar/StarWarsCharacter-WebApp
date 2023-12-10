import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import Typography from "@mui/material/Typography";
import { Box, CardActionArea, Grid } from "@mui/material";
import { useNavigate } from "react-router-dom";

const StarWarsCharacters = (props) => {
  const navigate = useNavigate();

  return (
    <Box>
      <Grid container rowSpacing={1} columnSpacing={{ xs: 1, sm: 2, md: 3 }}>
        {props.characters.map((character) => (
          <Grid item xs={12} sm={6} md={6} key={character.id}>
            <Card
              sx={{
                display: "flex",
                flexDirection: "column",
                height: "100%",
                textAlign: "center",
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
    </Box>
  );
};

export default StarWarsCharacters;
