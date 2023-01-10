vec4 effect(vec4 color, Image texture, vec2 tc, vec2 sc)
{
  vec4 tcolor = Texel(texture, tc);
  return vec4(239.0/255.0, 216.0/256.0, 161.0/256.0, tcolor.a);
}
