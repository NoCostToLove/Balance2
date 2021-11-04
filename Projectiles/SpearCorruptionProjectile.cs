using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Balance2.Projectiles
{
    public class SpearCorruptionProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.aiStyle = 19;
            Projectile.penetrate = -1;
            Projectile.alpha = 0;
            Projectile.scale = 1.2f;

            Projectile.friendly = true;
            Projectile.hide = true;
            Projectile.ownerHitCheck = true;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Melee;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 8;
        }

        public float movementFactor
        {
            get => Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];

            Vector2 mountedCenter = owner.RotatedRelativePoint(owner.MountedCenter, true);
            Projectile.direction = owner.direction;
            owner.heldProj = Projectile.whoAmI;
            owner.itemTime = owner.itemAnimation;

            Projectile.position.X = mountedCenter.X - (float)(Projectile.width / 2);
            Projectile.position.Y = mountedCenter.Y - (float)(Projectile.height / 2);

            if (!owner.frozen)
            {
                if (movementFactor == 0)
                {
                    movementFactor = 3f;
                    Projectile.netUpdate = true;
                }

                if (owner.itemAnimation < owner.itemAnimationMax / 3)
                {
                    movementFactor -= 2.4f;
                }

                else
                {
                    movementFactor += 2.1f;
                }
            }

            Projectile.position += Projectile.velocity * movementFactor;

            if (owner.itemAnimation == 0)
            {
                Projectile.Kill();
            }

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);

            if (Projectile.direction == -1)
            {
                Projectile.rotation -= MathHelper.ToRadians(90f);
            }

            if (Main.rand.Next(3) != 2)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Demonite);
            }
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (target.defense <= 15)
            {
                damage += target.defense / 2;
            }

            else
            {
                damage += 7;
            }
        }
    }
}
