import { Box, Typography } from "@mui/material";
import { useParams } from "react-router-dom";

const CharacterProfile = () => {
  let { characterId } = useParams();

  return (
    <Box
      m="0px 20px"
      display="flex"
      flexDirection="column"
      justifyContent="center"
      alignItems="center"
    >
      <Box>
        <Typography variant="h3">Test Character</Typography>
        <Typography variant="h5">ID: {characterId}</Typography>
      </Box>
    </Box>
  );
};

export default CharacterProfile;
