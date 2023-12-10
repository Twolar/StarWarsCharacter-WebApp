import { Box, Typography } from "@mui/material";

const Landing = () => {
  return (
    <Box
      m="0px 20px"
      display="flex"
      flexDirection="column"
      justifyContent="center"
      alignItems="center"
    >
      <Box>
        <Typography variant="h3">Welcome</Typography>
      </Box>

      <Box>
        <p>This is the landing page, more content to come here soon...</p>
      </Box>
    </Box>
  );
};

export default Landing;
