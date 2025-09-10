import { Box, Typography } from "../../assets/theme/components";

export const SimpleInfoBox = ({
  info,
  details,
}: {
  info: string;
  details?: string;
}) => (
  <Box
    sx={{
      flex: 1,
      display: "flex",
      alignItems: "center",
      justifyContent: "center",
      p: 4,
      textAlign: "center",
    }}
  >
    <Box
      sx={{
        p: 6,
        maxWidth: 400,
      }}
    >
      <Typography variant="h6" color="text.secondary">
        {info}
      </Typography>
      {details && (
        <Typography variant="body2" color="text.secondary" sx={{ mt: 1 }}>
          {details}
        </Typography>
      )}
    </Box>
  </Box>
);
