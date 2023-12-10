import { Box, Typography } from "@mui/material";

const Missing = () => {
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
    </Box>
  );
};

export default Missing;
