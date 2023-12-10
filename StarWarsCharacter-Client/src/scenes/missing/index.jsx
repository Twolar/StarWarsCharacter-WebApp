import { Box, Typography, Button } from "@mui/material";
import { useNavigate } from "react-router-dom";

const Missing = () => {
  const navigate = useNavigate();

  return (
    <Box
      m="0px 20px"
      display="flex"
      flexDirection="column"
      justifyContent="center"
      alignItems="center"
      textAlign="center"
    >
      <Box>
        <Typography variant="h3">404</Typography>
      </Box>

      <Box>
        <p>Oops, looks like the content you were looking for does not exist</p>
      </Box>

      <Box display="flex" justifyContent="start" mt="20px">
        <Button
          onClick={() => navigate("/")}
          color="secondary"
          variant="contained"
        >
          Back to Home
        </Button>
      </Box>
    </Box>
  );
};

export default Missing;
