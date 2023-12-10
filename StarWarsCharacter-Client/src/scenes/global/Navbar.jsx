import { Typography, Box } from "@mui/material";

const Navbar = () => {
  return (
    <Box
      display="flex"
      justifyContent="space-between"
      p={2}
      borderBottom={0.5}
      marginBottom={2}
      boxShadow={1}
    >
      <Typography>
        <img
          src="/r2d2.svg"
          alt="R2D2 Icon"
          style={{ maxWidth: 20, marginRight: "8px" }}
        />
        StarWarsCharacterApp
      </Typography>
    </Box>
  );
};

export default Navbar;
